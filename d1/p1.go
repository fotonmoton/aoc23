package main

import (
	"fmt"
	"os"
	"strconv"
	"strings"
	"unicode"
)

func fullGas[T any](data T, err error) T { return data }

func main() {
	sum := 0
	for _, line := range strings.Split(string(fullGas(os.ReadFile("p1_input.txt"))), "\n") {
		nums := strings.Map(func(r rune) rune {
			if unicode.IsNumber(r) {
				return r
			}
			return rune(-1)
		}, line)
		if len(nums) != 0 {
			sum += fullGas(strconv.Atoi(fmt.Sprintf("%s%s", string(nums[0]), string(nums[len(nums)-1]))))
		}
	}
	println(sum)
}
