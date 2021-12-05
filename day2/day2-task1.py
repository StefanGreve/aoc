#!/usr/bin/env python3

from __future__ import annotations

from collections import namedtuple
from typing import List

Command = namedtuple('Command', 'name value')

def read_file(path: str) -> List[Command]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        lines = [line.strip('\n').split() for line in file_handler.readlines()]
        return [Command(line[0], int(line[1])) for line in lines]

def course(path: str) -> int:
    pos = depth = 0

    for command in read_file(path):
        if command.name == 'forward':
            pos += command.value
        if command.name == 'down':
            depth += command.value
        if command.name == 'up':
            depth -= command.value

    return pos * depth

if __name__ == '__main__':
    result = course('input')
    print(f"{result} is the accumulated course value.")
