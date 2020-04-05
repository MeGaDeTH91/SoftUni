text = input()
brackets = []

for i in range(len(text)):
    if text[i] == "(":
        brackets.append(i)
    elif text[i] == ")":
        start_index = brackets.pop()
        print(text[start_index: i + 1])