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
