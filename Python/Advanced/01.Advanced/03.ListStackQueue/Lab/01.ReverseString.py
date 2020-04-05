inputStr = list(input())
resultStr = []
for x in range(len(inputStr)):
    resultStr.append(inputStr.pop())

print("".join(resultStr))