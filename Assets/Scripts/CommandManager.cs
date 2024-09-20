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

    public MoveCommand(Transform obj, Vector3 displacement)             //선언
    {
        this.objectToMove = obj;
        this.displacement = displacement;
    }
    
    public void Execute() { objectToMove.position += displacement; }    //Interface의 Excute가 실행될 때 obj 포지션에 더해지는 displacement
    public void Undo() { objectToMove.position -= displacement; }       //Undo 실행
}

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();             //스택 자료구조 형태로 커맨드 관리 되돌리기 (Undo)의 효과사용을 위함

    public void ExecuteCommand(ICommand command)
    {
        if (commandHistory.Count < 15)                                              //스테이지 별 카운트를 입력하면 다양한 스테이지 제작 가능
        {
            command.Execute();
            commandHistory.Push(command);                                           //스택에 넣기
            Debug.Log($"Command Count : {commandHistory.Count}");
        }
    }

    public void UndoLastCommand()
    {
        if(commandHistory.Count>0)
        {
            ICommand lastCommand = commandHistory.Pop();                        //스택에서 제외
            lastCommand.Undo();
            Debug.Log($"Command Count : {commandHistory.Count}");
        }
    }
    public IEnumerator ResetCommand()
    {
        while(commandHistory.Count > 0)
        {
            ICommand resetCommand = commandHistory.Pop();                       //카운트가 0이 될 때까지 스택 제외(초기화)
            resetCommand.Undo();
            Debug.Log($"Command Count : {commandHistory.Count}");
            yield return new WaitForSeconds(0.1f);
        }
    }
}

