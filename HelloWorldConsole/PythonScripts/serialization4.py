import time
import pandas as pd
import numpy as np

# First, let’s create a pandas dataframe with 100,000 rows of fake data:
# Set random seed
np.random.seed(123)

data = {'Column1': np.random.randint(0, 10, size=100000),
        'Column2': np.random.choice(['A', 'B', 'C'], size=100000),
        'Column3': np.random.rand(100000)}


# Create Pandas dataframe
df = pd.DataFrame(data)

start = time.time()

df.to_csv('my_pandas_dataframe.csv')

end = time.time()
print(end - start)

# Create Pickle file
start = time.time()

df.to_pickle("my_pandas_dataframe.pkl")

end = time.time()
print(end - start)

# Reading the csv file into Pandas:

start1 = time.time()
df_csv = pd.read_csv("my_pandas_dataframe.csv")
end1 = time.time()
print("Time taken to read the csv file: " + str(end1 - start1) + "\n")

# Reading the Pickle file into Pandas:

start2 = time.time()
df_pkl = pd.read_pickle("my_pandas_dataframe.pkl")
end2 = time.time()
print("Time taken to read the Pickle file: " + str(end2 - start2))
