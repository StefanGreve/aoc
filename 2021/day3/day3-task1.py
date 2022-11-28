#!/usr/bin/env python3

from typing import List

def read_file(path: str) -> List[str]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return [line.strip('\n') for line in file_handler.readlines()]

def main(path: str) -> int:
    lines = read_file(path)
    msb = lambda i: 1 if sum([int(line[i]) for line in lines]) > len(lines)/2 else 0
    gamma_rate = ''.join([str(msb(i)) for i in range(12)])
    epsilon_rate = gamma_rate.replace('1','2').replace('0','1').replace('2','0')
    return int(gamma_rate, 2) * int(epsilon_rate, 2)

if __name__ == '__main__':
    result = main('input')
    print(f"The current power consumption is {result}")
