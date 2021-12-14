#!/usr/bin/env python3

from typing import List

def read_file(path: str) -> List[int]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return list(map(int, file_handler.readline().split(',')))

def main(path: str) -> int:
    fuels = read_file(path)
    cost = lambda k: sum(map(lambda x: int(0.5*(pow(k-x, 2)+abs(k-x))), fuels))
    return min(map(cost, range(0, max(fuels))))

if __name__ == '__main__':
    result = main('input')
    print(f"The horizontal position that the crabs can align to using the least fuel possible is {result}.")
