#!/usr/bin/env python3

from __future__ import annotations

from itertools import chain
from typing import List

def read_file(path: str) -> List[str]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        return [line.strip('\n') for line in file_handler.readlines()]

def chunk(list_: List, size: int) -> List[List]:
    return [list_[i:i+size] for i in range(0, len(list_), size)]

class Board:
    def __init__(self, data: List[List[int]]) -> None:
        self.data = data
        self.dim = len(self.data[0])
        self.on_row = False
        self.on_col = False
        self.numbers = None

    @property
    def bingo(self) -> bool:
        return self.on_row or self.on_col

    def row(self, i: int=1) -> List[int]:
        return [self.data[i-1][j-1] for j in range(1, self.dim+1)]

    def col(self, j: int=1) -> List[int]:
        return [self.data[i-1][j-1] for i in range(1, self.dim+1)]

    @property
    def score(self) -> int:
        if self.bingo:
            return sum(set(chain.from_iterable(self.data)) - set(self.numbers)) * self.numbers[-1]

    def __str__(self) -> str:
        return ''.join(["{0:3}{1}".format(n, '\n' if i % self.dim == self.dim-1 else '') for row in self.data for i, n in enumerate(row)])

def main(path: str):
    content = read_file(path)
    numbers = list(map(int, content[0].split(',')))
    raw_board_data = [list(map(int, row.split())) for row in content[2:] if row]

    boards = [Board(data) for data in chunk(raw_board_data, 5)]

    winners = []
    ref_count = 0

    for turn in range(len(numbers)):
        for board in boards:
            draws = numbers[0:turn]
            for i in range(1, board.dim+1):
                board.on_row = set(board.row(i)).issubset(set(draws))
                board.on_col = set(board.col(i)).issubset(set(draws))
                if board.bingo and board not in winners:
                    board.numbers = draws
                    winners.append(board)
                    ref_count += 1

    return winners[-1]

if __name__ == '__main__':
    result = main('input')
    print(f"The final score is {result.score}. The winning board was:\n")
    print(result)
