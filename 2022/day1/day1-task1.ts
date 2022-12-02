import { readFileSync as read } from "fs";
import * as path from "path";
import { pipe } from "fp-ts/function";
import * as A from "fp-ts/Array";
import * as N from "fp-ts/number";

function readFile(file: string): number[] {
  return read(file, { encoding: "utf-8" })
    .split("\n")
    .map((s) => (!s ? 0 : Number(s)));
}

function findSums(data: number[]): number[] {
  let tmp = 0;
  let sums = [];

  data.forEach((n) => {
    if (n) {
      tmp += n;
    } else {
      sums.push(tmp);
      tmp = 0;
    }
  });

  return sums;
}

// main method
const file: string = path.join("2022", "day1", "input.txt");
const data: number[] = readFile(file);
const sums = findSums(data);

const part1 = Math.max(...sums);
const part2 = pipe(sums, A.sort(N.Ord)).slice(-3).sum();

const test = sums.chunkBy((n) => n === 0);

console.log(test);

// const result = chunkBy(data, (n) => n == 0);
// console.log(`The sum of all years is: ${result}`);
