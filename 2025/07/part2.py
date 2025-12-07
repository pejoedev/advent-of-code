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
endings = 0

def runState(ground_truth, index):
    global endings
    # print(index, ground_truth)
    current1 = []
    current2 = []
    ignoreIf = -1
    for j in range(maxWidth):
        if ground_truth[j]:
            if input_lines[index][j] == "^":
                ignoreIf = j+1
                current1.pop()
                current1.append(True)
                current1.append(False)
                if ignoreIf == j: continue
                current2.append(False)
                current2.append(True)
            else:
                current1.append(True)
                if ignoreIf == j: continue
                current2.append(True)
        else:
            current1.append(False)
            if ignoreIf == j: continue
            current2.append(False)

    if index + 1 == len(input_lines):
        endings += 1
        return
    if ",".join(str(b) for b in current1) == ",".join(str(b) for b in current2):
        runState(current1, index+1)
    else:
        runState(current1, index+1)
        runState(current2, index+1)

last = [c == "S" for c in input_lines[0]]
runState(last, 0)

print(endings)