import pickle
import numpy

with open("regressionX.pkl", "rb") as f:
    X = pickle.load(f)

with open("regressionY.pkl", "rb") as f:
    y = pickle.load(f)

with open("linear_regression.pkl", "rb") as f:
    unpickled_linear_model = pickle.load(f)

coef0 = unpickled_linear_model.coef_[0]
coef1 = unpickled_linear_model.coef_[1]
coef2 = unpickled_linear_model.coef_[2]

# summary of the model
# print("Model intercept :", unpickled_linear_model.intercept_)
# print("Model coefficients : ", unpickled_linear_model.coef_)
# print("Model score : ", unpickled_linear_model.score(X, y))

# print("Prediction initiated")
# print(unpickled_linear_model.predict(X))
# print("Prediction ended")