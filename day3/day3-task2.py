#!/usr/bin/env python3

from typing import List

def read_file(path: str) -> List[str]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return [line.strip('\n') for line in file_handler.readlines()]

def find_life_support_rating(lines: List[str], i: int=0, result: list=None, use_lsb: bool=True) -> str:
    msb = lambda i, lines: 1 if sum([int(line[i]) for line in lines]) >= len(lines)/2 else 0

    if len(lines) == 1:
        return
    else:
        j = str(1 - msb(i, lines) if use_lsb else msb(i, lines))
        lines = list(filter(lambda line: line[i] == j, lines))
        result.append(lines)
        find_life_support_rating(lines[:len(lines)], i+1, result, use_lsb)
        return result[-1][-1]

def main(path: str) -> int:
    r1, r2 = [], []
    lines = read_file(path)
    oxygen_generator_rating = find_life_support_rating(lines, 0, r1, use_lsb=False)
    co2_scrubber_rating = find_life_support_rating(lines, 0, r2, use_lsb=True)
    return int(oxygen_generator_rating, 2) * int(co2_scrubber_rating, 2)

if __name__ == '__main__':
    result = main('input')
    print(f"The life support of the submarine is {result}")
