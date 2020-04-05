class NameTooShortError(Exception):
    """Raised when the provided email name is too short"""
    def __init__(self):
        self.message = 'Name must be more than 4 characters'

    def __str__(self):
        return self.message


class MustContainAtSymbolError(Exception):
    """Raised when the provided email does not contain @ symbol"""
    def __init__(self):
        self.message = 'Email must contain @'

    def __str__(self):
        return self.message


class InvalidDomainError(Exception):
    """Raised when the provided email domain is not .com, .bg, .org or .net"""
    def __init__(self):
        self.message = 'Domain must be one of the following: .com, .bg, .org, .net'

    def __str__(self):
        return self.message


valid_domains = ['com', 'bg', 'org', 'net']

command = input()
while command != 'End':
    email = command

    if '@' not in email:
        raise MustContainAtSymbolError

    if len(email.split('@')[0]) < 5:
        raise NameTooShortError

    if '.' in email and email.split('.')[-1] not in valid_domains:
        raise InvalidDomainError

    print('Email is valid')
    command = input()
