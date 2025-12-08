# Read input once and store efficiently
with open('input.txt', 'r') as file:
    input_lines = file.read().strip().split('\n')

maxWidth = len(input_lines[0])
endings = 0

# Pre-allocate reusable arrays to avoid creating new ones each call
temp_state1 = [False] * maxWidth
temp_state2 = [False] * maxWidth

def states_equal(state1, state2, length):
    """Compare states without string conversion"""
    for i in range(length):
        if state1[i] != state2[i]:
            return False
    return True

def copy_state(source, dest, length):
    """Copy state efficiently"""
    for i in range(length):
        dest[i] = source[i]

def runState(ground_truth, index):
    global endings, temp_state1, temp_state2
    
    # Reset temp arrays
    current1_len = 0
    current2_len = 0
    ignoreIf = -1
    
    # Build states in-place
    for j in range(maxWidth):
        if ground_truth[j]:
            if input_lines[index][j] == "^":
                ignoreIf = j+1
                if current1_len > 0:
                    current1_len -= 1
                temp_state1[current1_len] = True
                current1_len += 1
                temp_state1[current1_len] = False
                current1_len += 1
                
                if ignoreIf != j:
                    temp_state2[current2_len] = False
                    current2_len += 1
                    temp_state2[current2_len] = True
                    current2_len += 1
            else:
                temp_state1[current1_len] = True
                current1_len += 1
                if ignoreIf != j:
                    temp_state2[current2_len] = True
                    current2_len += 1
        else:
            temp_state1[current1_len] = False
            current1_len += 1
            if ignoreIf != j:
                temp_state2[current2_len] = False
                current2_len += 1

    if index + 1 == len(input_lines):
        endings += 1
        if endings % 100000 == 0:  # Less frequent printing
            print(f"Found {endings} endings...")
        return
    
    # Compare without string conversion
    if current1_len == current2_len and states_equal(temp_state1, temp_state2, current1_len):
        runState(temp_state1[:current1_len], index+1)
    else:
        # Make copies only when needed
        state1_copy = temp_state1[:current1_len]
        state2_copy = temp_state2[:current2_len] if current2_len > 0 else []
        
        runState(state1_copy, index+1)
        if current2_len > 0:
            runState(state2_copy, index+1)

# Initialize with starting state
initial_state = [c == "S" for c in input_lines[0]]
runState(initial_state, 0)

print(f"Total endings: {endings}")