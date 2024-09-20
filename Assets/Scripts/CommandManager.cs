using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}
public class MoveCommand : ICommand
{
    private Transform objectToMove;
    private Vector3 displacement;

    public MoveCommand(Transform obj, Vector3 displacement)             //����
    {
        this.objectToMove = obj;
        this.displacement = displacement;
    }
    
    public void Execute() { objectToMove.position += displacement; }    //Interface�� Excute�� ����� �� obj �����ǿ� �������� displacement
    public void Undo() { objectToMove.position -= displacement; }       //Undo ����
}

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();             //���� �ڷᱸ�� ���·� Ŀ�ǵ� ���� �ǵ����� (Undo)�� ȿ������� ����

    public void ExecuteCommand(ICommand command)
    {
        if (commandHistory.Count < 15)                                              //�������� �� ī��Ʈ�� �Է��ϸ� �پ��� �������� ���� ����
        {
            command.Execute();
            commandHistory.Push(command);                                           //���ÿ� �ֱ�
            Debug.Log($"Command Count : {commandHistory.Count}");
        }
    }

    public void UndoLastCommand()
    {
        if(commandHistory.Count>0)
        {
            ICommand lastCommand = commandHistory.Pop();                        //���ÿ��� ����
            lastCommand.Undo();
            Debug.Log($"Command Count : {commandHistory.Count}");
        }
    }
    public IEnumerator ResetCommand()
    {
        while(commandHistory.Count > 0)
        {
            ICommand resetCommand = commandHistory.Pop();                       //ī��Ʈ�� 0�� �� ������ ���� ����(�ʱ�ȭ)
            resetCommand.Undo();
            Debug.Log($"Command Count : {commandHistory.Count}");
            yield return new WaitForSeconds(0.1f);
        }
    }
}

