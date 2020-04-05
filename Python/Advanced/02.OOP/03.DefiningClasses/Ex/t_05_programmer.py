class Programmer:
    name = ''
    language = ''
    skills = 0

    def __init__(self, name, language, skills):
        self.name = name
        self.language = language
        self.skills = skills

    def watch_course(self, course_name, language, skills_earned):
        if language == self.language:
            self.skills += skills_earned
            return f'{self.name} watched {course_name}'
        else:
            return f'{self.name} does not know {language}'

    def change_language(self, new_language, skills_needed):
        if new_language != self.language and skills_needed <= self.skills:
            previous_language = self.language
            self.language = new_language

            return f'{self.name} switched from {previous_language} to {new_language}'
        elif new_language == self.language and skills_needed <= self.skills:
            return f'{self.name} already knows {new_language}'
        elif skills_needed > self.skills:
            needed_skills = skills_needed - self.skills

            return f'{self.name} needs {needed_skills} more skills'
