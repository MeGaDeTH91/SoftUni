from collections import deque

bullet_price = int(input())
gun_barrel_size = int(input())
bullets = [int(x) for x in input().split()]
locks = deque(int(x) for x in input().split())
reward = int(input())

initial_bullet_count = len(bullets)
current_bullets = gun_barrel_size

while bullets and locks:
    current_bullet = bullets.pop()
    current_lock = locks.popleft()
    current_bullets -= 1

    if current_bullet <= current_lock:
        print('Bang!')
    else:
        locks.appendleft(current_lock)
        print('Ping!')

    if current_bullets == 0 and bullets:
        current_bullets = gun_barrel_size
        print('Reloading!')

if locks:
    print(f"Couldn't get through. Locks left: {len(locks)}")
else:
    bullets_left = len(bullets)
    earned = (reward - (initial_bullet_count - bullets_left) * bullet_price)
    print(f'{bullets_left} bullets left. Earned ${earned}')
