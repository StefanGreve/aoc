#!/usr/bin/env python3

from typing import List

def read_file(path: str) -> List[int]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return [int(line.strip('\n')) for line in file_handler.readlines()]

def count_sums(path: str) -> int:
    measurements = read_file(path)
    windows = lambda seq: [seq[i:i+3] for i in range(len(seq))]
    sums = list(map(sum, windows(measurements)))
    result = filter(lambda i: sums[i] > sums[i-1], range(len(sums)))
    return len(list(result))

if __name__ == '__main__':
    result = count_sums('input')
    print(f"{result} sums are larger than the previous ones")
