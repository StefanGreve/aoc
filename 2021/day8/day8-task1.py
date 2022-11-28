#!/usr/bin/env python3

from typing import List


def parse_output(path: str):
    with open(path, mode='r') as file_handler:
        return [line.split("|")[1].rstrip().split(" ") for line in file_handler]

def count_sequences(data: List[str]):
    return sum(1 for _ in filter(lambda s: len(s) in [2, 3, 4, 7], data))

if __name__ == "__main__":
    data = parse_output('input')
    result = sum(map(count_sequences, data))
    print(result)
