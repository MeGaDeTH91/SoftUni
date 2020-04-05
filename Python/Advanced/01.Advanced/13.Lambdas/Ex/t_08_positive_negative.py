numbers = [int(x) for x in input().split()]

negatives = list(filter(lambda x: x < 0, numbers))
positives = list(filter(lambda x: x >= 0, numbers))

negative_sum = sum(negatives)
positive_sum = sum(positives)

print(negative_sum)
print(positive_sum)

if abs(negative_sum) > abs(positive_sum):
    print('The negatives are stronger than the positives')
else:
    print('The positives are stronger than the negatives')
