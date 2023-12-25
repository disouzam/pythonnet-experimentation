import pickle

students = {
    'Student 1': {
        'Name': "Alice", 'Age': 10, 'Grade': 4,
    },

    'Student 2': {
        'Name': 'Bob', 'Age': 11, 'Grade': 5
    },

    'Student 3': {
        'Name': 'Elena', 'Age': 14, 'Grade': 8
    }
}

# serialize the dictionary to a pickle file

with open("student_dict.pkl", "wb") as f:
    pickle.dump(students, f)

# deserialize the dictionary and print it out

with open("student_dict.pkl", "rb") as f:
    deserialized_dict = pickle.load(f)
    print(deserialized_dict)
    print(type(deserialized_dict))

print(
    "The first student's name is "
    + deserialized_dict["Student 1"]["Name"]
    + " and she is "
    + (str(deserialized_dict["Student 1"]["Age"]))
    + " years old."
)
