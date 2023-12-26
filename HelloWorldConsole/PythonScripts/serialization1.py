print("Starting a sample script")

students = {
    "Student 1": {
        "Name": "Alice",
        "Age": 10,
        "Grade": 4,
    },
    "Student 2": {"Name": "Bob", "Age": 11, "Grade": 5},
    "Student 3": {"Name": "Elena", "Age": 14, "Grade": 8},
}

print("This is the type of students:")
print(type(students))

print("Writing students to file...")
with open(file="student_info.txt", mode="w", encoding="utf8") as data:
    data.write(str(students))

print("Reading students to file...")
with open("student_info.txt", mode="r", encoding="utf8") as f:
    for students in f:
        print(students)

print("This is the type of students after writing it to a text file:")
print(type(students))
