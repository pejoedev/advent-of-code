# helper for visualisation
def pretty_print_2d(arr):
    print("[")
    for row in arr:
        nums = ['|' if x else '.' for x in row]
        print("  [" + ",".join(str(n) for n in nums) + "],")
    print("]")


# Read input.txt into a variable
with open('input.txt', 'r') as file:
    input_data = file.read()

# Alternative: Read as a list of lines (without newline characters)
with open('input.txt', 'r') as file:
    input_lines = file.read().strip().split('\n')

# Alternative: Read as a list of lines (keeping newline characters)
with open('input.txt', 'r') as file:
    input_lines_with_newlines = file.readlines()

# Print to verify the data was loaded
print("Raw input data:")
print(repr(input_data))
print("\nAs list of lines:")
print(input_lines)
print(f"\nNumber of lines: {len(input_lines)}")
maxWidth = len(input_lines[0])
print(maxWidth)
splits = 0

last = [c == "S" for c in input_lines[0]]
tree = []
for i in range(len(input_lines)):
    print("loop ", i)
    current = []
    ignoreIf = -1
    for j in range(maxWidth):
        if ignoreIf == j: continue
        if last[j]:
            if input_lines[i][j] == "^":
                ignoreIf = j+1
                current.pop()
                current.append(True)
                current.append(False)
                current.append(True)
                splits+=1
            else:
                current.append(True)
        else:
            current.append(False)
    last = current
    tree.append(last)

pretty_print_2d(tree)
print(splits)