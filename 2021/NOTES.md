# Notes for AOC 2021

Albeit very short lived, this year was the year of Python - well, at least for
me personally. During this year I tried to establish some conventions, the most
important of which are listed below in case I go back to this challenge:

1. Since there are two tasks for each day, files are named uniquely following
   this pattern: `2021/dayX/dayX-taskY.py`
2. Each day probably has to implements a `read_file(path: str) -> List[str]` method,
   though the return type might not always be a list of strings
3. Store the final result in a `result` variable and print the output
