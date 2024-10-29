using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jumper
{
    private NavMeshAgent _agent;
    private Coroutine _jumpCoroutine;
    private AnimationCurve _jumpCurve;
    private MonoBehaviour _context;
    private float _jumpTime;

    public Jumper(MonoBehaviour context, NavMeshAgent agent)
    {
        _context = context;
        _agent = agent;
    }

    public void Jump(AnimationCurve jumpCurve, float jumpTime)
    {
        _jumpCurve = jumpCurve;
        _jumpTime = jumpTime;

        if (_jumpCoroutine == null)
        {
            _jumpCoroutine = _context.StartCoroutine(Jump(_jumpTime, _jumpCurve));
            return;
        }
    }

    private IEnumerator Jump(float duration, AnimationCurve _jumpCurve)
    {
        OffMeshLinkData data = _agent.currentOffMeshLinkData;

        Vector3 startPos = _agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * _agent.baseOffset;

        float progress = 0;

        while (progress < duration)
        {
            float yOffset = _jumpCurve.Evaluate(progress / duration);
            _agent.transform.position = Vector3.Lerp(startPos, endPos, progress / duration) + Vector3.up * yOffset;
            _agent.transform.rotation = Quaternion.LookRotation(endPos - startPos);
            progress += Time.deltaTime;

            yield return null;
        }

        _agent.CompleteOffMeshLink();
        _jumpCoroutine = null;
    }
}
