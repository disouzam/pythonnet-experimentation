import numpy as np
import pickle

numpy_array = np.ones((10, 10))  # 10x10 array

with open('my_array.pkl', 'wb') as f:
    pickle.dump(numpy_array, f)

with open('my_array.pkl', 'rb') as f:
    unpickled_array = pickle.load(f)
    print('Array shape: '+str(unpickled_array.shape))
    print('Data type: '+str(type(unpickled_array)))
