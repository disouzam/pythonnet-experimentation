import pickle

student_names = ['Alice', 'Bob', 'Elena', 'Jane', 'Kyle']

with open('student_file.pkl', 'wb') as f:  # open a text file
    pickle.dump(student_names, f)  # serialize the list
f.close()

with open('student_file.pkl', 'rb') as f:
    student_names_loaded = pickle.load(f)  # deserialize using load()
    print(student_names_loaded)  # print student names

print(type(student_names_loaded))
