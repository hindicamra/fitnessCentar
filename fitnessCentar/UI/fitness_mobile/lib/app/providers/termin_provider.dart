import 'package:fitness_mobile/app/models/training_model.dart';
import 'package:fitness_mobile/app/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:fluttertoast/fluttertoast.dart';

class TerminProvider extends ChangeNotifier {
  final formKey = GlobalKey<FormBuilderState>();
  final String formName = 'dateRange';
  String? startDate;
  String? endDate;
  ValueNotifier<bool> refreshing = ValueNotifier(false);
  List<TrainingModel> listOfTrainings = [];

  resetDate() {
    formKey.currentState!.fields[formName]?.reset();
  }

  searchWithDate(bool isFirstTime) async {
    /// Mock data for now
    refreshing.value = true;
    await Future.delayed(const Duration(seconds: 2));
    if (!isFirstTime) {
      DateTimeRange? date = formKey.currentState!.fields[formName]?.value;
      if (date != null) {
        startDate = Utils().formatDate(date.start);
        endDate = Utils().formatDate(date.end);
      }
    }
    listOfTrainings.add(
      TrainingModel(
        1,
        '02/02/2024',
        1,
        'Test 123',
        'Arms',
        500,
      ),
    );
    refreshing.value = false;
    //TODO make api call and send data
  }

  showDialogToBuy(BuildContext context, TrainingModel trainingModel) {
    showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
        title: const Text('Rezerviši trening?'),
        content: const Text("Da li zelite da rezervišete ovaj trening?"),
        actions: [
          TextButton(
            onPressed: () {
              //TODO Add to cart, add this later
              //TODO Show user that he added in cart and he cant add same thing again
              refreshing.value = true;
              listOfTrainings.remove(trainingModel);
              refreshing.value = false;
              Fluttertoast.showToast(
                msg: "Uspešno ste poslali trening na rezervaciju",
                toastLength: Toast.LENGTH_LONG,
                gravity: ToastGravity.BOTTOM,
                backgroundColor: Colors.green,
                textColor: Colors.black,
                fontSize: 16.0,
              );
              Navigator.of(context).pop();
            },
            child: const Text('Da'),
          ),
          TextButton(
            onPressed: () {
              Navigator.of(context).pop();
            },
            child: const Text('Ne'),
          )
        ],
      ),
    );
  }
}
