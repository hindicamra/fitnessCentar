import 'package:fitness_admin/models/user_model.dart';
import 'package:flutter/material.dart';

class IzmenaZaposlenihProvider extends ChangeNotifier {
  UserModel? userModel;

  TextEditingController name = TextEditingController();
  TextEditingController surname = TextEditingController();
  TextEditingController username = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController phone = TextEditingController();
  TextEditingController address = TextEditingController();
  TextEditingController status = TextEditingController();
  TextEditingController role = TextEditingController();

  setUserModel(UserModel userModelData) {
    userModel = userModelData;
  }

  setData() {
    name.text = userModel?.ime ?? '';
    surname.text = userModel?.prezime ?? '';
    username.text = userModel?.korisnickoIme ?? '';
    email.text = userModel?.email ?? '';
    phone.text = userModel?.telefon ?? '';
    address.text = userModel?.adresa ?? '';
    status.text = userModel?.status ?? '';
    role.text = (userModel?.ulogaId == 1) ? 'Admin' : 'Radnik';
  }

  saveUser(BuildContext context) {
    //TODO send api call to save user
    Navigator.pop(context, true);
  }

  deleteUser(BuildContext context) {
    //TODO send api call to delete user
    Navigator.pop(context, true);
  }
}
