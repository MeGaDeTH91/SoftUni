def get_repeating_DNA(text):
    outer_start_index = 0
    outer_end_index = 10

    result = []

    while outer_end_index <= len(text):
        outer_dna = text[outer_start_index: outer_end_index]

        inner_start_index = outer_start_index + 1
        inner_end_index = outer_end_index + 1
        while inner_end_index <= len(text):
            inner_dna = text[inner_start_index: inner_end_index]

            if outer_dna == inner_dna and outer_dna not in result:
                result.append(outer_dna)

            inner_start_index += 1
            inner_end_index += 1

        outer_start_index += 1
        outer_end_index += 1

    return result