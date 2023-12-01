local sum = 0

local words = {
  one = "1",
  two = "2",
  three = "3",
  four = "4",
  five = "5",
  six = "6",
  seven = "7",
  eight = "8",
  nine = "9"
}


for line in assert(io.open("p2_input.txt", "rb")):read("*all"):gmatch("[^\r\n]+") do
  local nums = {}
  local i = 1
  while i <= #line do
    local moved = false
    local first = line:sub(i, i)
    if tonumber(first) ~= nil then
      table.insert(nums, first)
    else
      for k, v in pairs(words) do
        local startWith = line:sub(i, i + string.len(k) - 1)
        if startWith == k then
          table.insert(nums, v)
          i = i + string.len(k) - 1
          moved = true
        end
      end
    end
    if not moved then
      i = i + 1
    end
  end
  if next(nums) then
    local pair = (nums[1] .. nums[#nums])
    sum = sum + tonumber(pair)
  end
end
print(sum)
