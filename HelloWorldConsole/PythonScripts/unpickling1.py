import pickle

from sklearn.datasets import make_regression

with open("regressionX.pkl", "rb") as f:
    X = pickle.load(f)

with open("regressionY.pkl", "rb") as f:
    y = pickle.load(f)

with open("linear_regression.pkl", "rb") as f:
    unpickled_linear_model = pickle.load(f)

# summary of the model
print('Model intercept :', unpickled_linear_model.intercept_)
print('Model coefficients : ', unpickled_linear_model.coef_)
print('Model score : ', unpickled_linear_model.score(X, y))

print("Prediction initiated")
print(unpickled_linear_model.predict(X))
print("Prediction ended")

newX, y = make_regression(n_samples=5, n_features=3, noise=0.7, random_state=1)

print("Prediction initiated on new X")
print(unpickled_linear_model.predict(newX))
print("Prediction ended")