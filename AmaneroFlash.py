import time
import serial
import serial.tools.list_ports
import requests
from tqdm import tqdm
from pathlib import Path

print('Waiting for Amanero Combo384 USB card...\n')

COMPORT = None
while COMPORT == None:
    for port in serial.tools.list_ports.comports():
        if port.pid == 0x6124:
            COMPORT = port.name
            print(f'* {port.description} / VID={"%0.4X" % port.vid} / PID={"%0.4X" % port.pid} / SN={port.serial_number}\n')

CPLD = {
    'CPLD_for_1080': 'firmware/CPLD/CPLD_for_1080.txt',
    'CPLD_for_1081': 'firmware/CPLD/CPLD_for_1081.txt',
    'CPLD_1080_DSDSWAPPED': 'firmware/CPLD/CPLD_1080_DSDSWAPPED.txt',
    'CPLD_1081_DSDSWAPPED': 'firmware/CPLD/CPLD_1081_DSDSWAPPED.txt',
}

CPU = {
    'DSD512x48x44': 'firmware/CPU/DSD512x48x44.txt',
    'firmware_1096c3w2': 'firmware/CPU/firmware_1096c3w2.txt',
    'firmware_1096c4w2': 'firmware/CPU/firmware_1096c4w2.txt',
    'firmware_1099c': 'firmware/CPU/firmware_1099c.txt',
    'firmware_1099akm': 'firmware/CPU/firmware_1099akm.txt',
    'firmware_2006be10': 'firmware/CPU/firmware_2006be10.txt',
    'firmware_2006be11': 'firmware/CPU/firmware_2006be11.txt',
}

print('====== CPLD Firmware ======')
for text in CPLD:
    print(f'* {text}')
print()

print('====== CPU Firmware =======')
for text in CPU:
    print(f'* {text}')
print()

fw = None
while fw == None:
    option = input('Enter CPLD/CPU firmware:\n')
    if fw == None: fw = CPLD.get(option)
    if fw == None: fw = CPU.get(option)
    print()

fw_path = Path.cwd().joinpath(fw)

if not fw_path.is_file():
    r = requests.get('https://raw.githubusercontent.com/sabpprook/AmaneroFlash/main/' + fw)
    if r.status_code == 200:
        if not fw_path.parent.exists():
            fw_path.parent.mkdir(755, True, True)
        open(fw_path, 'wb').write(r.content)

payload = open(fw_path, 'r').read().splitlines()

with serial.Serial(COMPORT, 115200, 8, 'N', 1) as ser:
    pbar = tqdm(desc=option, total=sum([len(x) for x in payload]), colour='YELLOW')
    pbar.bar_format = '{desc}: {percentage:3.0f}%|{bar:20}| {n_fmt}/{total_fmt}'

    for line in payload:
        data = line.encode('ascii')
        ser.write(data)
        time.sleep(0.01)
        if line != 'W400E1200,A5000005#':
            ser.read_all()
        pbar.update(len(data))

time.sleep(1)