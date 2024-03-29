import 'package:fitness_admin/models/user_model.dart';
import 'package:fitness_admin/providers/izmena_zaposlenih_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class IzmenaZaposlenihScreen extends StatefulWidget {
  const IzmenaZaposlenihScreen({super.key});

  @override
  State<IzmenaZaposlenihScreen> createState() => _IzmenaZaposlenihScreenState();
}

class _IzmenaZaposlenihScreenState extends State<IzmenaZaposlenihScreen> {
  late IzmenaZaposlenihProvider izmenaZaposlenihProvider;

  @override
  void initState() {
    izmenaZaposlenihProvider = context.read<IzmenaZaposlenihProvider>();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final userModel = ModalRoute.of(context)!.settings.arguments as UserModel;
    izmenaZaposlenihProvider.setUserModel(userModel);
    izmenaZaposlenihProvider.setData();

    return Scaffold(
      appBar: AppBar(
        foregroundColor: Colors.white,
        backgroundColor: Colors.blue,
        centerTitle: true,
        title: Text(
          'Zaposleni: ${izmenaZaposlenihProvider.userModel?.ime}',
        ),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(15),
          child: Column(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Ime: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        width: 300,
                        child: TextFormField(
                          style: const TextStyle(
                            color: Colors.black,
                          ),
                          keyboardType: TextInputType.name,
                          controller: izmenaZaposlenihProvider.name,
                          decoration: const InputDecoration(
                            fillColor: Colors.white,
                            filled: true,
                            enabledBorder: OutlineInputBorder(
                              borderSide:
                                  BorderSide(color: Colors.black, width: 2.0),
                            ),
                            hintText: "Name",
                            hintStyle: TextStyle(color: Colors.grey),
                          ),
                        ),
                      ),
                    ],
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Prezime: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        width: 300,
                        child: TextFormField(
                          style: const TextStyle(
                            color: Colors.black,
                          ),
                          keyboardType: TextInputType.name,
                          controller: izmenaZaposlenihProvider.surname,
                          decoration: const InputDecoration(
                            fillColor: Colors.white,
                            filled: true,
                            enabledBorder: OutlineInputBorder(
                              borderSide:
                                  BorderSide(color: Colors.black, width: 2.0),
                            ),
                            hintText: "Prezime",
                            hintStyle: TextStyle(color: Colors.grey),
                          ),
                        ),
                      ),
                    ],
                  )
                ],
              ),
              const SizedBox(
                height: 30,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Korisničko Ime: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        width: 300,
                        child: TextFormField(
                          style: const TextStyle(
                            color: Colors.black,
                          ),
                          keyboardType: TextInputType.name,
                          controller: izmenaZaposlenihProvider.username,
                          decoration: const InputDecoration(
                            fillColor: Colors.white,
                            filled: true,
                            enabledBorder: OutlineInputBorder(
                              borderSide:
                                  BorderSide(color: Colors.black, width: 2.0),
                            ),
                            hintText: "Korisničko Ime",
                            hintStyle: TextStyle(color: Colors.grey),
                          ),
                        ),
                      ),
                    ],
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Email: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        width: 300,
                        child: TextFormField(
                          style: const TextStyle(
                            color: Colors.black,
                          ),
                          keyboardType: TextInputType.emailAddress,
                          controller: izmenaZaposlenihProvider.email,
                          decoration: const InputDecoration(
                            fillColor: Colors.white,
                            filled: true,
                            enabledBorder: OutlineInputBorder(
                              borderSide:
                                  BorderSide(color: Colors.black, width: 2.0),
                            ),
                            hintText: "Email",
                            hintStyle: TextStyle(color: Colors.grey),
                          ),
                        ),
                      ),
                    ],
                  ),
                ],
              ),
              const SizedBox(
                height: 30,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Telefon: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        width: 300,
                        child: TextFormField(
                          style: const TextStyle(
                            color: Colors.black,
                          ),
                          keyboardType: TextInputType.phone,
                          controller: izmenaZaposlenihProvider.phone,
                          decoration: const InputDecoration(
                            fillColor: Colors.white,
                            filled: true,
                            enabledBorder: OutlineInputBorder(
                              borderSide:
                                  BorderSide(color: Colors.black, width: 2.0),
                            ),
                            hintText: "Telefon",
                            hintStyle: TextStyle(color: Colors.grey),
                          ),
                        ),
                      ),
                    ],
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Adresa: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      SizedBox(
                        width: 300,
                        child: TextFormField(
                          style: const TextStyle(
                            color: Colors.black,
                          ),
                          keyboardType: TextInputType.text,
                          controller: izmenaZaposlenihProvider.address,
                          decoration: const InputDecoration(
                            fillColor: Colors.white,
                            filled: true,
                            enabledBorder: OutlineInputBorder(
                              borderSide:
                                  BorderSide(color: Colors.black, width: 2.0),
                            ),
                            hintText: "Adresa",
                            hintStyle: TextStyle(color: Colors.grey),
                          ),
                        ),
                      ),
                    ],
                  ),
                ],
              ),
              const SizedBox(
                height: 30,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Status: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      DropdownButton<int>(
                        value: izmenaZaposlenihProvider.status,
                        icon: const Icon(Icons.arrow_drop_down),
                        elevation: 16,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        underline: Container(
                          height: 2,
                          color: Colors.black,
                        ),
                        onChanged: (int? value) {
                          setState(() {
                            izmenaZaposlenihProvider.status = value ?? 1;
                          });
                        },
                        items: izmenaZaposlenihProvider.dropDownStatusItems,
                      ),
                    ],
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'Uloga: ',
                        style: TextStyle(fontSize: 16, color: Colors.black),
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      DropdownButton<int>(
                        value: izmenaZaposlenihProvider.role,
                        icon: const Icon(Icons.arrow_drop_down),
                        elevation: 16,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        underline: Container(
                          height: 2,
                          color: Colors.black,
                        ),
                        onChanged: (int? value) {
                          setState(() {
                            izmenaZaposlenihProvider.role = value ?? 1;
                          });
                        },
                        items: izmenaZaposlenihProvider.dropDownRoleItems,
                      ),
                    ],
                  ),
                ],
              ),
              const SizedBox(
                height: 30,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  SizedBox(
                    width: 300,
                    child: TextButton(
                      onPressed: () =>
                          izmenaZaposlenihProvider.saveUser(context),
                      child: Container(
                        height: 50,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          color: Colors.blue,
                        ),
                        child: const Center(
                            child: Text(
                          'Sačuvaj',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 16.0,
                          ),
                        )),
                      ),
                    ),
                  ),
                  SizedBox(
                    width: 300,
                    child: TextButton(
                      onPressed: () =>
                          izmenaZaposlenihProvider.deleteUser(context),
                      child: Container(
                        height: 50,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          color: Colors.blue,
                        ),
                        child: const Center(
                            child: Text(
                          'Obriši',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 16.0,
                          ),
                        )),
                      ),
                    ),
                  ),
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
