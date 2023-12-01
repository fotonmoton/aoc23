console.log(
  require("node:fs")
    .readFileSync("p1_input.txt", "utf8")
    .split("\n")
    .map((line) =>
      Number(
        `${line.split("").filter(Number).shift()}${line
          .split("")
          .filter(Number)
          .pop()}`
      )
    )
    .reduce((acc, val) => acc + val, 0)
);
