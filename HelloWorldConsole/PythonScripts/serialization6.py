import pickle
from sklearn.linear_model import LinearRegression
from sklearn.datasets import make_regression

# generate regression dataset
X, y = make_regression(n_samples=100, n_features=3, noise=0.1, random_state=1)

with open("regressionX.pkl", "wb") as f:
    pickle.dump(X, f)

with open("regressionY.pkl", "wb") as f:
    pickle.dump(y, f)

# train regression model
linear_model = LinearRegression()
linear_model.fit(X, y)

# summary of the model
print('Model intercept :', linear_model.intercept_)
print('Model coefficients : ', linear_model.coef_)
print('Model score : ', linear_model.score(X, y))

with open("linear_regression.pkl", "wb") as f:
    pickle.dump(linear_model, f)

with open("linear_regression.pkl", "rb") as f:
    unpickled_linear_model = pickle.load(f)

# summary of the model
print('Model intercept :', unpickled_linear_model.intercept_)
print('Model coefficients : ', unpickled_linear_model.coef_)
print('Model score : ', unpickled_linear_model.score(X, y))
