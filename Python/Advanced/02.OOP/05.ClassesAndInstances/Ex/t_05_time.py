class Time:
    max_hours = 24
    max_minutes = 60
    max_seconds = 60

    def __init__(self, hours, minutes, seconds):
        self.hours = hours
        self.minutes = minutes
        self.seconds = seconds

    def set_time(self, hours, minutes, seconds):
        self.hours = hours
        self.minutes = minutes
        self.seconds = seconds

    def get_time(self):
        return f'{self.hours:02d}:{self.minutes:02d}:{self.seconds:02d}'

    def next_second(self):
        self.seconds += 1
        if self.seconds >= self.max_seconds:
            self.seconds = 0
            self.minutes += 1

            if self.minutes >= self.max_minutes:
                self.minutes = 0
                self.hours += 1

                if self.hours > self.max_hours:
                    self.hours = 1

        return self.get_time()
