n = int(input())

usernames = set()

for _ in range(n):
    usernames.add(input())

for name in usernames:
    print(name)
