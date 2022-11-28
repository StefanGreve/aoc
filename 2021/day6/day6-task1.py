#!/usr/bin/env python3

from collections import Counter
from typing import List

def read_file(path: str) -> List[int]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return list(map(int, file_handler.readlines()[0].strip('\n').split(',')))

def sim_lanternfish_growth(path: str) -> List[int]:
    days, internal_states = 80, read_file(path)

    for _ in range(days):
        previous_day = Counter(internal_states)
        internal_states = [i-1 if i > 0 else 6 for i in internal_states]
        internal_states.extend([8] * previous_day[0])

    return internal_states

if __name__ == '__main__':
    result = sim_lanternfish_growth('input')
    print(f"The result is {len(result)}.")
