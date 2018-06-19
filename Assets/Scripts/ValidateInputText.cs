using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValidateInputText : MonoBehaviour {
	InputField input;

	void Start() {
		input = GetComponent<InputField> ();
		input.onValidateInput += ValidateInput;
	}

	public char ValidateInput(string text, int charIndex, char addedChar) {
		if (char.IsSurrogate (addedChar)) {
			// サロゲートペアの場合には削除
			addedChar = '\0';
		}
		return addedChar;
	}
}
