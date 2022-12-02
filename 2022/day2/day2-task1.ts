import { readFileSync as read } from "fs";
import * as path from "path";
import { pipe } from "fp-ts/function";
import * as A from "fp-ts/Array";
import * as N from "fp-ts/number";

function readFile(file: string): string[][] {
  return read(file, { encoding: "utf-8" })
    .split("\n")
    .filter(Boolean)
    .map((s) => s.split(" "))
    .map((s) => [s[0], s[1]]);
}

function decodeMove(move: string) {
  switch (move) {
    case "A":
    case "X":
      return 1;
    case "B":
    case "Y":
      return 2;
    case "C":
    case "Z":
      return 3;
    default:
      throw new Error(`invalid input: ${move}`);
  }
}

// PART 1

/**
 * Implements a game of rock-paper-scissors.
 * @param player1 Rock=0, Paper=1, Scissors=2
 * @param player2 Rock=0, Paper=1, Scissors=2
 * @reference https://stackoverflow.com/a/2795421/10827244
 * @returns 1 if player1 wins, 2 if player2 wins, else zero (draw)
 */
function rockPaperScissors(player1: number, player2: number): number {
  return (3 + player1 - player2) % 3;
}

function outcomeToPoint(out: number): number {
  return out == 2 ? 6 : out == 0 ? 3 : 0;
}

function evaluateStrategy(data: string[][]): number {
  const input: number[][] = data.map((d) => [decodeMove(d[0]), decodeMove(d[1])]);

  const scores = pipe(
    input,
    A.map((p) => [rockPaperScissors(p[0] - 1, p[1] - 1), p[1]]),
    A.map((m) => [outcomeToPoint(m[0]), m[1]]),
    A.flatten,
    A.reduce(0, (a, b) => a + b)
  );

  return scores;
}

// PART 2

function encodeMove(moveA: number, moveB: number): number {
  return {
    1: (moveA > 1 ? moveA - 1 : 3) + 0,
    2: moveA + 0,
    3: (moveA > 0 && moveA < 3 ? moveA + 1 : 1) + 0,
  }[moveB];
}

function evaluateSecretStrategy(data: string[][]): number[] {
  const input: number[][] = data.map((d) => [decodeMove(d[0]), decodeMove(d[1])]);

  const result = pipe(
    input,
    A.map((p) => encodeMove(p[0], p[1]))
    // A.map((p) => [decodeHiddenMessage(p[0], p[1]), outcomeToPoint(p[1])])
    // A.flatten,
    // A.reduce(0, (a, b) => a + b)
  );

  return result;
}

// main method
const file: string = path.join("2022", "day2", "input.txt");
const data: string[][] = readFile(file);

// const part1: number = evaluateStrategy(data);
const part2: number[] = evaluateSecretStrategy(data);

console.log(part2);
