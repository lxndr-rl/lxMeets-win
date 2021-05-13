import sys
from tqdm import tqdm
import requests
import platform
import shutil
import tempfile
import os
import json
import psutil

if(platform.system() != 'Windows'):
    print(f'{platform.system()} no es compatible con esta versión')
    input('Presione Enter para continuar')
    exit()

chunk_size = 1024

dict_json = json.loads(json.dumps(requests.get(
    f'https://lxmeets.lxndr.dev/latest.php').json()))

PROCNAME = "lxMeets.exe"
try:
    with tempfile.TemporaryDirectory() as tmp_dir:
        r = requests.get(dict_json['windowsFile'], stream=True)
        total_size = int(r.headers['content-length'])
        filename = 'lxMeets.exe'
        with open(f"{tmp_dir}\{filename}", 'wb') as f:
            for data in tqdm(iterable=r.iter_content(chunk_size=chunk_size), total=total_size/chunk_size, unit='KB'):
                f.write(data)
        print(f"lxMeets descargado...\nMoviendo a {sys.argv[1]}...\n\n")
        for proc in psutil.process_iter():
            if proc.name() == PROCNAME:
                print('Cerrando lxMeets...\n\n')
                proc.kill()
                break
        shutil.move(os.path.join(tmp_dir, filename),
                    os.path.join(sys.argv[1], filename))
        print("Iniciando...")
        os.startfile(f"{sys.argv[1]}\{filename}")
        input("Presione Enter para terminar la actualización")
except ValueError:
    print(f'Error {ValueError}')
    input("Presione Enter para salir")
