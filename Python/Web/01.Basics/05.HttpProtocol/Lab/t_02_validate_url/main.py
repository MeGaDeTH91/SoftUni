from urllib import parse
import urllib
import re

regex = re.compile(
        r'^(?:http|ftp)s?://' # http:// or https://
        r'(?:(?:[A-Z0-9](?:[A-Z0-9-]{0,61}[A-Z0-9])?\.)+(?:[A-Z]{2,6}\.?|[A-Z0-9-]{2,}\.?)|' #domain...
        r'localhost|' #localhost...
        r'\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})' # ...or ip
        r'(?::\d+)?' # optional port
        r'(?:/?|[/?]\S+)$', re.IGNORECASE)

decoded_url = parse.unquote(input())

decoded_url = urllib.parse.urlparse(decoded_url)

if not re.match(regex, decoded_url.geturl()) is not None or\
        not decoded_url.scheme or not decoded_url.hostname or not decoded_url.path:
    print('Invalid URL')
else:
    port = decoded_url.port if decoded_url.port else 80

    if not decoded_url.port:
        if decoded_url.scheme.lower() == 'https':
            port = 443

    print(f'Protocol: {decoded_url.scheme}')
    print(f'Host: {decoded_url.hostname}')
    print(f'Port: {port}')
    print(f'Path: {decoded_url.path}')

    if decoded_url.query:
        print(f'Query: {decoded_url.query}')
    if decoded_url.fragment:
        print(f'Fragment: {decoded_url.fragment}')
