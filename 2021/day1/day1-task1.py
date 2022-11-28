#!/usr/bin/env python3

from typing import List

def read_file(path: str) -> List[int]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return [int(line.strip('\n')) for line in file_handler.readlines()]

def count(path: str) -> int:
    measurements = read_file(path)
    result = filter(lambda i: measurements[i] > measurements[i-1], range(1, len(measurements)))
    return len(list(result))

if __name__ == '__main__':
    result = count('input')
    print(f"{result} measurements are larger than the previous ones.")
