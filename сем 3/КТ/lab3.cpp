#include<iostream>
#include<string>
#include<list>

using namespace std;

enum tok_names { semocolon, ident, num, asgn, parentheses, OR, boolean, constants };
struct token
{
	enum tok_names token_name;
	string token_names[11] = { "Semocolon", "ident", "Number", "Assign", "Parentheses", "OR", "boolean", "constants" };
	string token_value;
};
list<token> lexeme_table;

token add_token(tok_names a, string b) {
	token tok;

	tok.token_name = a;
	tok.token_value = b;

	return tok;
}
list<token> lexer(string str)
{
	list<token> lexeme_table;

	int i = 0; int value = 0;
	while (i < str.size())
	{
		if (str[i] == ':' and str[i + 1] == '=') {
			lexeme_table.push_back(add_token(asgn, ":="));
			i += 2;
		}

		if (str[i] == ';') {
			lexeme_table.push_back(add_token(semocolon, ";"));
		}

		if (str[i] == '(') {
			lexeme_table.push_back(add_token(parentheses, "("));
		}
		if (str[i] == ')') {
			lexeme_table.push_back(add_token(parentheses, ")"));
		}

		if (str[i] == 'o' and str[i + 1] == 'r') {
			lexeme_table.push_back(add_token(OR, "or"));
			i += 2;
		}

		if (str[i] == '<') {
			string con = "<";
			i++;
			while (str[i] >= '0' and str[i] <= '9')
			{
				con += str[i];
				i++;
			}
			con += ">";
			lexeme_table.push_back(add_token(constants, con));
		}

		if (str[i] == '|') {
			lexeme_table.push_back(add_token(OR, "or"));
			i++;
		}

		if ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z')) {
			string var = "";
			while ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z') or (str[i] >= '0' and str[i] <= '9'))
			{
				var += str[i];
				i++;
			}
			i--;
			lexeme_table.push_back(add_token(ident, var));
		}

		if ((str[i] >= '0' and str[i] <= '9')) {
			string number = "";
			while (str[i] >= '0' and str[i] <= '9')
			{
				number += str[i];
				i++;
			}
			i--;
			lexeme_table.push_back(add_token(num, number));
		}

		i++;
	}
	return lexeme_table;
}

struct node
{
	token token;                           //Информационное поле
	node* l, * r;                        //Левая и Правая часть дерева
};
node* tree = NULL;                      //Объявляем переменную, тип которой структура Дерево

void pushTree(token token, node** t) //Add
{
	if ((*t) == NULL)                   //Если дерева не существует
	{
		(*t) = new node;                //Выделяем память
		(*t)->token = token;                 //Кладем в выделенное место аргумент a
		(*t)->l = (*t)->r = NULL;       //Очищаем память для следующего роста
		return;                         //Заложили семечко, выходим
	}

	if (token.token_name != constants and token.token_name != num and token.token_name != ident) {
		pushTree(token, &(*t)->r);
		return;
	}
	if ((token.token_name == constants or token.token_name == num or token.token_name == ident) and (*t)->l == NULL) {
		pushTree(token, &(*t)->l);
		return;
	}
	else {
		pushTree(token, &(*t)->r);
		return;
	}
}

void printTree(node* t, int u, bool Direction)
{
	if (t == NULL) return;                  //Если дерево пустое, то отображать нечего, выходим
	else
	{

		printTree(t->l, ++u, 1);                   //С помощью рекурсивного посещаем левое поддерево
		cout << u;
		cout << ' ';
		if (u != 1) Direction == 1 ? cout << "l " : cout << "r ";
		cout << t->token.token_value << endl;
		u--;
	}
	printTree(t->r, ++u, 0);                       //С помощью рекурсии посещаем правое поддерево
}

int main()
{
	token tok;
	string str = "fortnite or PABAG ; <9678>";
	list<token> lexeme_table = lexer(str);


	list<token> temp = lexeme_table;
	while (temp.empty() == 0) {
		tok = temp.front();
		cout << "name:" << tok.token_names[tok.token_name] << ", " << "value:" << tok.token_value << endl;
		temp.pop_front();
	}
	cout << endl;

	list<token> znak;
	list<token> identif;
	temp = lexeme_table;
	while (temp.size() > 0)
	{
		if (temp.front().token_name == num or temp.front().token_name == constants or temp.front().token_name == ident) {
			identif.push_back(temp.front());
			temp.pop_front();
		}
		else {
			znak.push_back(temp.front());
			temp.pop_front();
		}
	}

	node* sosna = NULL;

	while (znak.size() > 0 or identif.size() > 0)
	{
		if (znak.size() > 0) {
			pushTree(znak.front(), &sosna);
			znak.pop_front();
		}
		else
		{
			pushTree(identif.front(), &sosna);
			identif.pop_front();
		}
	}


	printTree(sosna, 0, 1);
}
