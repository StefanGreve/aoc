#!/usr/bin/env python3

from collections import Counter
from typing import List

def read_file(path: str) -> List[int]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return list(map(int, file_handler.readlines()[0].strip('\n').split(',')))

def sim_lanternfish_growth(path: str) -> int:
    days, internal_states = 256, Counter(read_file(path))

    lanternfish_population = sum(internal_states)
    rotate = lambda state: (state[1], state[2], state[3], state[4], state[5], state[6], state[7] + state[0], state[8], state[0])

    for _ in range(days):
        internal_states = rotate(tuple(map(lambda i: internal_states[i] or 0, range(9))))
        lanternfish_population = sum(internal_states)

    return lanternfish_population

if __name__ == '__main__':
    result = sim_lanternfish_growth('input')
    print(f"The result is {result}.")
