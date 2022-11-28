#!/usr/bin/env python3

from collections import Counter, namedtuple
from typing import Dict, List

Point = namedtuple('Point', 'x y')

def read_file(path: str) -> List[int]:
    with open(path, mode='r', encoding='utf-8') as file_handler:
        content = [','.join(line.strip('\n').split(' -> ')) for line in file_handler.readlines()]
        return [list(map(int, line.split(','))) for line in content]

def gen_points(coords: List[int]):
    diagram = []
    for tup in coords:
        if tup[0] == tup[2]:
            m, M = min(tup[1], tup[3]), max(tup[1], tup[3])
            diagram.extend(Point(tup[0], y) for y in range(m, M+1))
        if tup[1] == tup[3]:
            m, M = min(tup[0], tup[2]), max(tup[0], tup[2])
            diagram.extend(Point(x, tup[1]) for x in range(m, M+1))

    return diagram

def get_intersections(points: List[Point]) -> Dict[Point, int]:
    return [(k,v) for k,v in Counter(points).items() if v > 1]

if __name__ == '__main__':
    points = gen_points(read_file('input2'))
    result = len(get_intersections(points))
    print(f"{result} points intersect at least once.")
