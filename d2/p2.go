package main

import (
	"bufio"
	"math"
	"os"
	"regexp"
	"strconv"
)

func floorIt[T any](data T, err error) T { return data }

func main() {

	if len(os.Args) != 2 {
		panic("where is a file?")
	}

	findTakes := regexp.MustCompile("([0-9]+) (green|red|blue)")
	scanner := bufio.NewScanner(floorIt(os.Open(os.Args[1])))
	scanner.Split(bufio.ScanLines)

	sum := 0
	for scanner.Scan() {
		minColors := map[string]int{
			"green": 0,
			"blue":  0,
			"red":   0,
		}
		for _, take := range findTakes.FindAllStringSubmatch(scanner.Text(), -1) {
			minColors[take[2]] = int(math.Max(float64(floorIt(strconv.Atoi(take[1]))), float64(minColors[take[2]])))
		}
		sum += minColors["green"] * minColors["red"] * minColors["blue"]
	}
	println(sum)
}
