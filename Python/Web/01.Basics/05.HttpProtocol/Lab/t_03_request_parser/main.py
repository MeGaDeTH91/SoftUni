paths = []

command = input()
while command != 'END':
    paths.append(command)
    command = input()

search_params = input().split()
request_type = search_params[0].lower()
search_path = search_params[1][1:].lower()
http_protocol = search_params[2]
result = None

for path in paths:
    tokens = list(filter(len, path.split('/')))
    current_path = tokens[0]
    current_request_type = tokens[1]
    if request_type == current_request_type and search_path == current_path:
        result = True

if not result:
    print(f'{http_protocol} 404 Not Found')
    print('Content-Length: 9')
    print('Content-Type: text/plain\n')
    print('Not Found')
else:
    print(f'{http_protocol} 200 OK')
    print('Content-Length: 2')
    print('Content-Type: text/plain\n')
    print('OK')
