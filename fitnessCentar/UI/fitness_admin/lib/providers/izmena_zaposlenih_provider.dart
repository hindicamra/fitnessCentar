import 'package:fitness_admin/models/user_model.dart';
import 'package:fitness_admin/utils/constants.dart';
import 'package:fitness_admin/utils/utils.dart';
import 'package:flutter/material.dart';

class IzmenaZaposlenihProvider extends ChangeNotifier {
  UserModel? userModel;

  TextEditingController name = TextEditingController();
  TextEditingController surname = TextEditingController();
  TextEditingController username = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController phone = TextEditingController();
  TextEditingController address = TextEditingController();

  int? status;
  int? role;

  List<DropdownMenuItem<int>> dropDownStatusItems = [
    DropdownMenuItem(
      alignment: AlignmentDirectional.center,
      value: UserStatus.active.value,
      child: const Text(AppConstants.active),
    ),
    DropdownMenuItem(
      alignment: AlignmentDirectional.center,
      value: UserStatus.nonActive.value,
      child: const Text(AppConstants.nonActive),
    ),
  ];

  List<DropdownMenuItem<int>> dropDownRoleItems = [
    DropdownMenuItem(
      alignment: AlignmentDirectional.center,
      value: UserRole.admin.value,
      child: const Text(AppConstants.admin),
    ),
    DropdownMenuItem(
      alignment: AlignmentDirectional.center,
      value: UserRole.user.value,
      child: const Text(AppConstants.user),
    ),
  ];

  setUserModel(UserModel userModelData) {
    userModel = userModelData;
  }

  setData() async {
    name.text = userModel?.ime ?? '';
    surname.text = userModel?.prezime ?? '';
    username.text = userModel?.korisnickoIme ?? '';
    email.text = userModel?.email ?? '';
    phone.text = userModel?.telefon ?? '';
    address.text = userModel?.adresa ?? '';
    status ??= userModel?.status;
    role ??= userModel?.ulogaId;
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
