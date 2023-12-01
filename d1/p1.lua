local sum = 0
for line in assert(io.open("p1_input.txt", "rb")):read("*all"):gmatch("[^\r\n]+") do
  local nums = {}
  line:gsub(".", function(c)
    if tonumber(c) ~= nil then
      table.insert(nums, c)
    end
  end)
  if next(nums) then
    sum = sum + tonumber((nums[1] .. nums[#nums]))
  end
end
print(sum)
