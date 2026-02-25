class User {
  constructor(password) {
    this._password = password;
  }
  get password() {
    return this._password;
  }
  set password(newPassword) {
    if (newPassword.length >= 6) {
      this._password = newPassword;
    } else {
      console.log("Error: Password must be at least 6 characters.");
    }
  }
}