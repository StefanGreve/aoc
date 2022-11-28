import { readFileSync as read } from "fs";
import * as path from "path";
import { pipe } from "fp-ts/function";
import * as A from "fp-ts/Array";

function readFile(file: string): number[] {
  return read(file, { encoding: "utf-8" })
    .split("\n")
    .filter(Boolean)
    .map((line) => Number(line.substring(3)));
}

function computeSum(data: number[]): number {
  return pipe(
    data,
    A.reduce(0, (prev: number, cur: number) => prev + cur)
  );
}

function main() {
  const file: string = path.join("2022", "day1", "input.txt");
  const data: number[] = readFile(file);
  const result = computeSum(data);
  console.log(`The sum of all years is: ${result}`);
}

main();
